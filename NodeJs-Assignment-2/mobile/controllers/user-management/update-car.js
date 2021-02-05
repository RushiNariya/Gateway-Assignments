var HttpStatusCode = require("http-status-codes");
var dbConnection = require('../../../utilities/postgresql-connection.js');
var imageUrlConfig = require('../../../config.js');

exports.updateCar = function (req, res) {
    var entityData = {
        Id: req.params.id
    };

    function validateFields(req, res) {
        return new Promise(function (resolve, reject) {
            
            return resolve({
                status: HttpStatusCode.StatusCodes.OK,
                data: entityData
            });
        });
    }

    function updateCar(req, entityData) {
        return new Promise(function (resolve, reject) {

            let carname = req.body.carname;
            let makename = req.body.makename;
            let modelname = req.body.modelname;

            dbConnection.checkUpdateCar(entityData.Id, modelname, makename).then(function(response){

                if(response.data[0] != null ){
                    //console.log('car exists update then');
                    //console.log(response.data[0], '------------' + response.data[1]);
                    const sqlQuery = `UPDATE car SET name = ${carname}, modelid = ${response.data[0]}, makeid = ${response.data[1]} WHERE id = ${entityData.Id};`;

                    dbConnection.updateCar(carname, response.data[0], response.data[1], entityData.Id).then(function (response) {
        
                            return resolve({
                                status: HttpStatusCode.StatusCodes.OK,
                                data: response,
                                message: 'Car Updated successfully!!!'
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
                        message: 'Car Doesn\'t exists!!!'
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
        updateCar(req, response.data).then(function (response) {
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