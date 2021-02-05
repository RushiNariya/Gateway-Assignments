var HttpStatusCode = require("http-status-codes");
var dbConnection = require('../../../utilities/postgresql-connection.js');
var imageUrlConfig = require('../../../config.js');

exports.deleteCar = function (req, res) {
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

    function deleteCar(req, entityData) {
        return new Promise(function (resolve, reject) {

            dbConnection.deleteCarById(entityData.Id).then(function (response) {
                
                if (response.data[0] != null) {

                    return resolve({
                        status: HttpStatusCode.StatusCodes.OK,
                        data: response,
                        message: 'Car deleted successfully!!!'
                    });
                    
                } else {

                    return resolve({
                        status: HttpStatusCode.StatusCodes.OK,
                        data: [],
                        message: 'Car doesn\'t Exist!!!'
                    });
                }                
            })
            .catch(function (error) {
                res.status(error.status).json({
                    data: error.data
                });
            });
        });
    }

    validateFields(req, res).then(function (response) {
        deleteCar(req, response.data).then(function (response) {
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