const fs = require('fs');
const csvParser = require('csv-parser');
const createCsvWriter = require('csv-writer').createObjectCsvWriter;
const { DateTime } = require('luxon');
const mysql = require('mysql2');

/*---- VARIAVEIS ----*/ 
    // Set variables
    const sourceFilePath = 'csv-exemplo.csv'; // Path to the CSV with the columns to be extracted - inserir PATH do ficheiro no servidor
    const targetColumns = ['Empregado', 'Nome', 'Cd_Categoria']; // Names of the columns to extract from source file  
    const databaseColumns = ['num', 'nome', 'cat'];
    const tableName = 'empregados';


/*--- IR AO FICHEIRO BUSCAR AS 3 COLUNAS ----*/
function run(){
    const result = {};

    // Initialize the result object with arrays for each target column
    targetColumns.forEach((column) => {
    result[column] = [];
    });
    
    fs.createReadStream(sourceFilePath)
    .pipe(csvParser({ separator: ';' })) // Specify the delimiter as a comma
    .on('data', (row) => {
        targetColumns.forEach((column) => {
        if (row.hasOwnProperty(column)) {
            result[column].push(row[column]);
        }
        });
    })
    .on('end', () => {
    
        // Now 'result' contains the data from the specified columns in separate arrays
        console.log(result);
          
        // You can access the individual arrays like this:
        var column1Data = Object.values(result)[0];
        var column2Data = Object.values(result)[1];
        var column3Data = Object.values(result)[2];
        var columnDataAll = [column1Data,column2Data,column3Data];
    
        function processColumns(column1Data, column2Data, column3Data) {
          // Your code to work with the arrays goes here
            // For example, you can perform calculations or other operations on the data
            console.log('Column 1 Data:', column1Data);
            console.log('Column 2 Data:', column2Data);
            console.log('Column 3 Data:', column3Data);
          }
    
        // Now that CSV parsing is complete, call processColumns function
        processColumns(column1Data, column2Data, column3Data);
        /*---- BASE DE DADOS ----*/
    
            // Connect to database
            // Database configuration
            const connection = mysql.createConnection({
                host: '127.0.0.1',
                user: 'root',
                password: '2001_Cof',
                database: 'cacifos',
            });
      
            // Connect to the database
  
              connection.connect((err) => {
                if (err) {
                console.error('Error connecting to the database:', err);
                return;
                }
                console.log('Connected to the MySQL database!');
            });
  
      
            
  
            // SQL query to update the specified column
  
                  for (i=0;i<3;i++){

                    const updateQuery = `UPDATE ${tableName} SET ${databaseColumns[i]} = ? WHERE id = ?`;
      
                    // Execute the updates for each element in the dataArray
                    columnDataAll[i].forEach((value, index) => {
                      const id = index + 1; // Assuming you have an ID column starting from 1
                      //const insertQuery = `INSERT INTO ${tableName} (id) VALUES (${id}) `
                      connection.query(updateQuery, [value,id], (error, results) => {
                          if (error) {
                            console.error(`Error updating row with ID ${id}:`, error);
                          } else {
                            console.log(`Row with ID ${id} updated successfully!`);
                          }
                        });
                    });
                  };
                  // Close the connection 
  
                    connection.end((err) => {
                        if (err) {
                        console.error('Error closing the database connection:', err);
                        return;
                        }
                        console.log('Database connection closed.');
                    });
    });
    
    
            
            
        
};

function runDailyRoutine() {
  // Get the current time
  const now = new Date();

  // Set the time for your desired daily routine (e.g., 12:00 PM)
  const targetTime = new Date(now);
  targetTime.setHours(11, 44, 0, 0); // 12:00 PM

  // Calculate the time difference between now and the target time
  let timeDiff = targetTime - now;

  // If the target time has already passed today, add 24 hours to the time difference
  if (timeDiff < 0) {
    timeDiff += 20 * 1000; // Add 24 hours in milliseconds
  }

  // Start the interval to run the routine
  setInterval(() => {
    run();
    // Re-calculate the time difference for the next day
    timeDiff = 20 * 1000; // 24 hours in milliseconds
  }, timeDiff);
}

// Start running the daily routine
runDailyRoutine();
