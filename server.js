const express = require('express');
const bodyParser = require('body-parser');
const fs = require('fs');
const mysql = require('mysql2');

const app = express();
const port = 3000;

function createDataFile() {
    const dataFilePath = 'data.txt';
    if (!fs.existsSync(dataFilePath)) {
        fs.writeFileSync(dataFilePath, 'id, water_level, motor_status, timestamp\n');
        console.log('Файл даних успішно створено.');
    }
}

createDataFile();

let id = 1;

app.use(bodyParser.json());

const db = mysql.createConnection({
    host: 'localhost',
    user: 'root',
    password: 'root',
    database: 'water_level_db'
});

db.connect((err) => {
    if (err) {
        console.error('Помилка підключення до бази даних:', err);
    } else {
        console.log('Підключення до бази даних успішно встановлено.');
    }
});

function formatDateToMySQL(date) {
    return date.toISOString().slice(0, 19).replace('T', ' ');
}

app.post('/data', (req, res) => {
    const { WaterLevel, MotorStatus } = req.body;

    const timestamp = formatDateToMySQL(new Date());

    const newData = `${id}, ${WaterLevel}, ${MotorStatus}, ${timestamp}\n`;

    fs.appendFile('data.txt', newData, (err) => {
        if (err) {
            console.error('Помилка під час запису у файл:', err);
            res.status(500).send('Помилка під час запису даних у файл');
        } else {
            console.log('Дані успішно записано у файл.');
        }
    });

    const query = 'INSERT INTO water_data (water_level, motor_status, timestamp) VALUES (?, ?, ?)';
    db.execute(query, [WaterLevel, MotorStatus, timestamp], (err, results) => {
        if (err) {
            console.error('Помилка під час запису у базу даних:', err);
            res.status(500).send('Помилка під час запису даних у базу даних');
        } else {
            console.log('Дані успішно записано у базу даних.');
            res.status(200).send('Дані успішно записано у файл та базу даних');
        }
    });

    id++;
});

app.get('/data', (req, res) => {
    fs.readFile('data.txt', 'utf8', (err, data) => {
        if (err) {
            console.error('Помилка під час читання з файлу:', err);
            res.status(500).send('Помилка під час отримання даних з файлу');
        } else {
            res.send(data);
        }
    });
});

app.get('/data/:id', (req, res) => {
    const id = req.params.id;

    fs.readFile('data.txt', 'utf8', (err, data) => {
        if (err) {
            console.error('Помилка під час читання з файлу:', err);
            res.status(500).send('Помилка під час отримання даних з файлу');
        } else {
            const rows = data.split('\n').filter(row => row.trim() !== ''); 
            const row = rows.find(row => row.startsWith(`${id},`));

            if (!row) {
                res.status(404).send('Дані з вказаним id не знайдено');
            } else {
                res.send(row);
            }
        }
    });
});

app.listen(port, () => {
    console.log(`Server launched on port: ${port}`);
});
