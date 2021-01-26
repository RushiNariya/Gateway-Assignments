const Pool = require('pg').Pool
const pool = new Pool({
  user: 'postgres',
  host: 'localhost',
  database: 'CarDatabase',
  password: '123456',
  port: 5432,
})


const getCars = (request, response) => {
  pool.query('SELECT car.name as CarName, model.name as ModelName, make.name as MakerName FROM car JOIN model ON car.modelid = model.id JOIN make ON car.makeid = make.id;', (error, results) => {
    if (error) {
      throw error
    }
    response.status(200).json(results.rows)
  })
}


const getCarById = (request, response) => {
  const id = parseInt(request.params.id)

  pool.query('SELECT car.name as CarName, model.name as ModelName, make.name as MakerName FROM car JOIN model ON car.modelid = model.id JOIN make ON car.makeid = make.id where car.id = $1;', [id], (error, results) => {
    if (error) {
      throw error
    }
    response.status(200).json(results.rows)
  })
}

module.exports = {
  getCars,
  getCarById
}


// SELECT car.name, model.name, make.name FROM car JOIN model ON car.modelid = model.id JOIN make ON car.makeid = make.id;