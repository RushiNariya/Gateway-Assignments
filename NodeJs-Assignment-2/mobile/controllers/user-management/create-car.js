var HttpStatusCode = require("http-status-codes");
var dbConnection = require('../../../utilities/postgresql-connection.js');
var imageUrlConfig = require('../../../config.js');

exports.createNewCar = function (req, res) {
    var entityData = {};

    function validateFields(req, res) {
        return new Promise(function (resolve, reject) {
            
            return resolve({
                status: HttpStatusCode.StatusCodes.OK,
                data: entityData
            });
        });
    }

    function createNewCar(req, entityData) {
        return new Promise(function (resolve, reject) {

            let carname = req.body.carname;
            let makename = req.body.makename;
            let modelname = req.body.modelname;

            dbConnection.checkCarExist(carname, modelname, makename).then(function(response){

                if(response.data[0] != null ){

                    const sqlQuery = `insert into car (name, modelid, makeid) values (${carname}, ${response.data[0]}, ${response.data[1]});`;

                    dbConnection.insertCar(carname, response.data[0], response.data[1]).then(function (response) {
        
                            return resolve({
                                status: HttpStatusCode.StatusCodes.CREATED,
                                data: response,
                                message: 'Car Added successfully!!!'
                            });
                    })
                    .catch(function (error) {
                        res.status(error.status).json({
                            data: error.data
                        });
                    });
                }
                else{

                    return resolve({
                        status: HttpStatusCode.StatusCodes.OK,
                        data: [],
                        message: 'Car already exists!!!'
                    });
                    
                }

            }).catch(function (error) {
                res.status(error.status).json({
                    data: error.data
                });
            });
        });
    }

    validateFields(req, res).then(function (response) {
        createNewCar(req, response.data).then(function (response) {
            res.status(response.status).json({
                data: response.data.data,
                message: response.message
            });
        })
        .catch(function (error) {
            res.status(error.status).json({
                data: error.data
            });
        });
    })
    .catch(function (error) {
        res.status(error.status).json({
            data: error.data
        });
    });
    
}