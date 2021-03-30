//Post Customers AWS Lambda API

const mysql = require('mysql');
const bcrypt = require('bcryptjs');
const multipart = require("lambda-multipart-parser");
const sharp = require('sharp');

const AWS = require('aws-sdk');
const ID = 'AKIA2LIQVDYS7PRKOGXP';
const SECRET = '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';
const s3 = new AWS.S3({
    accessKeyId: ID,
    secretAccessKey: SECRET
})


const uploadImage = (path, file) =>
  new Promise((resolve, reject) => {
    let params = {
      ACL: "public-read",
      Bucket: "rushi-test-bucket",
      Key: path,
      Body: file,
      ContentType: "image/png",
    };

    s3.upload(params)
      .promise()
      .then((data) => {
        resolve(true);
      })
      .catch((err) => {
        reject(err);
      });
  });

const insertData = (name, email, password, contactNumber, imagepath, thumbnailpath) => new Promise((resolve, reject) => {
    try {
        const connection = mysql.createConnection({
          host: "customermanagement.cqpug1sw78bk.ap-south-1.rds.amazonaws.com",
          user: "admin",
          password: "dhrumitAdmin",
          database: "customermanagement",
        });
        const insertQuery = `INSERT INTO Customers (name, email, password, contactnumber, image, thumbnail, status)
            VALUES ('${name}', '${email}', '${password}', '${contactNumber}', '${imagepath}', '${thumbnailpath}', ${true})`;
        connection.query(insertQuery, (err, result, fields) => {
            if(err) {
                connection.destroy();
                reject(err);
            } else {
                connection.end();
                resolve(true);
            }
        });
    } catch(err) {
        throw err;
    }

});

exports.handler = async (event, context, cb) => {
    
    try{
    let req = await multipart.parse(event);
    let name = req.name;
    let email = req.email;
    let password =  bcrypt.hashSync(req.password, 8);
    let contactNumber = req.contactNumber;
    console.log(req);
    
    let file = req.files[0];
    let decodedImage = Buffer.from(file.content, "base64");
    let decodedThumbnail = await sharp(decodedImage).resize(200).toBuffer();

    let fileExtension = ".png";
    
    const date = new Date();
    const newDate = date.toISOString().replace("T", "_").replace(/:/g, "-").replace(".","-");

    
    let imagePath = "images/" + newDate + fileExtension;
    let thumbnailPath = "thumbnails/" + newDate + fileExtension;

    
    let promises = [];
    promises.push(insertData(name, email, password, contactNumber, imagePath, thumbnailPath));
    promises.push(uploadImage(imagePath, decodedImage));
    promises.push(uploadImage(thumbnailPath, decodedThumbnail));

     await Promise.all(promises).then((values) => {
         if (values[0] && values[1]) {
          cb(null, {
            statusCode: 201,
             headers:{
                        "Access-Control-Allow-Origin":"*"
                    },
            body: "created",
            isBase64Encoded: false,
          });
        } else {
            cb({
            statusCode: 400,
            headers:{
                        "Access-Control-Allow-Origin":"*"
                    },
            body: "error occured",
            isBase64Encoded: false,
          }, null);
        }
     }).catch((error) => {
         console.log(error)
          cb({
            statusCode: 400,
          headers:{
                        "Access-Control-Allow-Origin":"*"
                    },
            body: error.message,
            isBase64Encoded: false,
          }, null);
     });
        
    }catch(error){
        console.log(error.message)
         cb({
            statusCode: 400,
            headers:{
                        "Access-Control-Allow-Origin":"*"
                    },
            body: error.message,
            isBase64Encoded: false,
          }, null);
    }
    
   
    
}