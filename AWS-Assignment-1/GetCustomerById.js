// Get Customer By Id AWS lambda API

const mysql = require('mysql');

exports.handler = (event, context, cb) => {
    
    const connection = mysql.createConnection({
        host : 'customermanagement.cqpug1sw78bk.ap-south-1.rds.amazonaws.com',
        database : 'customermanagement',
        user : 'admin',
        password : 'dhrumitAdmin'
    });
    
    try{
        const query =`SELECT id, name, email, contactnumber, thumbnail, status from Customers WHERE status = true AND id = ${event.pathParameters.id}`;
        
        connection.query(query, (error, results, fields) => {
            if(error){
                connection.destroy();
                throw error;
            }
            else{
                results[0].thumbnail =  'https://rushi-test-bucket.s3.ap-south-1.amazonaws.com/' + results[0].thumbnail;
                cb(null, {
                    "statusCode" : 200,
                     "headers": {
                        "Access-Control-Allow-Origin": "*"
                    },
                    "body" : JSON.stringify(results[0]),
                    "isBase64Encoded" : false
                });
                connection.end();
            }
        });
    }catch(err){
        connection.end();
        cb({
            "statusCode" : 500,
             "headers": {
                "Access-Control-Allow-Origin": "*"
            },
            "body" : "error occured",
            "isBase64Encoded" : false
        });
    }
}