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

const getCarsWithImages = (request, response) => {
  pool.query('SELECT car.id as id, car.name as CarName, model.name as ModelName, make.name as MakerName, carimage.imagename as image from car JOIN model ON car.modelid = model.id JOIN make ON car.makeid = make.id left join carimage on car.id = carimage.carid;', (error, results) => {
    if (error) {
      throw error
    }
    // console.log('------------------------')

    const updateRows = [];

    // console.log(results.rows)

results.rows.forEach(function(item) {
  var tempArray = updateRows.filter(function(value) {
    return value.id == item.id;
  });
  // console.log(tempArray)
  if (tempArray.length) {
    var matchIndex = updateRows.indexOf(tempArray[0]);
    updateRows[matchIndex].image = updateRows[matchIndex].image.concat(item.image);
  } else {
    if (typeof item.image == 'string')
      item.image = [item.image];
      updateRows.push(item);
  }
});

results.rows = [...updateRows]

    // console.log('------------------------')

    //console.log(results)
    response.status(200).json(results.rows)
  })
}


const getCarById = (request, response) => {
  const id = parseInt(request.params.id)

  pool.query('SELECT car.name as CarName, model.name as ModelName, make.name as MakerName FROM car JOIN model ON car.modelid = model.id JOIN make ON car.makeid = make.id where car.id = $1;', [id], (error, results) => {
    if (error) {
      throw error
    }
    console.log(results.rows)
    response.status(200).json(results.rows)
  })
}

//----------------------------------------------------------------------------------------------------
// const checkmake =async (modelid, makename, carname) =>{
//   let makeid;
//   console.log('hello1sasf')
//   pool.query('select * from make where name = $1', [makename], (error, results) => {
//     if (results.rows.length > 0) {
//       makeid = results.rows[0].id
//       console.log('makeid: ' + makeid)
//       pool.query('insert into car (name, modelid, makeid) values ($1, $2, $3)', [carname, modelid, makeid], (error, results) => {
//         console.log('car added')
//         return `car added successfully`
//       })
//     }
//     else {
//       pool.query('insert into make (name) values ($1)', [makename], (error, results) => {
//         if (results.rowCount > 0) {
//           pool.query('select * from make where name = $1', [makename], (error, results) => {
//             if (results.rows.length > 0) {
//               makeid = results.rows[0].id
//               pool.query('insert into car (name, modelid, makeid) values ($1, $2, $3)', [carname, modelid, makeid], (error, results) => {
//                 return `car added successfully`
//               })
//             }
//           })
//         }
//       })
//     }
//   })
// }

// const createCar = async (request, response) => {
//   let carname  = (request.body.carname).toString();
//   let makename  = request.body.makename;
//   let modelname  = request.body.modelname;

//   //pool.query('INSERT INTO users (username, email) VALUES ($1, $2)', [name, email], (error, results) => {
//     //check car exist or not
//   pool.query('select * from car where name = $1',[carname], (error, results) => {
//     //console.log(results)
//     if (error) {
//       throw error
//     }
//     if(results.rows.length > 0){
//         console.log('car exist')
//         response.status(201).send(`car already exists`)
//     }
//     else{
//       pool.query('select * from model where name = $1',[modelname],(error, results) => {
//         let modelid;
//           if(results.rows.length > 0){
//             modelid = results.rows[0].id;
//             console.log('modelid : ' + modelid)
//             checkmake(modelid, makename, carname).then((value) => {
//               console.log(`inside then`)
//               console.log('value: ' + value)
//               response.status(201).send(value)
//             }).catch((err) => {
//               respons.send(`sorry`)
//             });
//           }
//           else{
//             pool.query('insert into model (name) values ($1)',[modelname], (error, results) => {
//               if(results.rowCount > 0){
//                 console.log('inserted model')
//                 pool.query('select * from model where name = $1',[modelname], (error, results) => {
//                   if(results.rows.length > 0){
//                     modelid = results.rows[0].id;
//                     console.log('modelid : ' + modelid)
//                     checkmake(modelid, makename, carname).then((value) => {
//                       console.log(`inside then`)
//                       console.log('value: ' + value)
//                       response.status(201).send(value)
//                     }).catch((err) => {
//                       response.send(`sorry`)
//                     });
//                   }
//                 })
//               }
//             })
//           }
//       })
//     }
//     //check model exist or not


//   })
// }

//-----------------------------------------------------------------------------------------------------



// SELECT car.name, model.name, make.name FROM car JOIN model ON car.modelid = model.id JOIN make ON car.makeid = make.id;
//----------------------------------------------

const createCar = async (request, response) => {
  let carname = request.body.carname;
  let makename = request.body.makename;
  let modelname = request.body.modelname;
  let modelid;
  let makeid;

   const checkCar = await pool.query('select * from car where name = $1',[carname]);

   if(checkCar.rows.length > 0){
    console.log('car exist')
    response.status(201).send(`car already exists`)
   }
   else{

    const checkModel = await pool.query('select * from model where name = $1',[modelname]);
    const checkMake = await pool.query('select * from make where name = $1',[makename]);

    if(checkModel.rows.length > 0){
      modelid = checkModel.rows[0].id;
      console.log('model exists id :' + modelid)
    }
    else{
      const newModel = await pool.query('insert into model (name) values ($1)',[modelname]);
      const newmodelid = await pool.query('select * from model where name = $1',[modelname]);
      modelid = newmodelid.rows[0].id;
      console.log('new model id :' + modelid)
    }

    if(checkMake.rows.length > 0){
      makeid = checkMake.rows[0].id;
      console.log('make exists id :' + makeid)

    }
    else{
      const newMake = await pool.query('insert into make (name) values ($1)',[makename]);
      const newmakeid = await pool.query('select * from make where name = $1',[makename]);
      makeid = newmakeid.rows[0].id;
      console.log('new make id :' + makeid)
   }

   pool.query('insert into car (name, modelid, makeid) values ($1, $2, $3)', [carname, modelid, makeid], (error, results) =>{
     if(error){
       throw error;
     }
     console.log('car added')
     response.status(201).send(`car added successfully`)
   })

  }
}

const updateCar = async (request, response) => {

  const id = parseInt(request.params.id)

  let carname = request.body.carname;
  let makename = request.body.makename;
  let modelname = request.body.modelname;
  let modelid;
  let makeid;

  const checkCar = await pool.query('select * from car where id = $1',[id]);

  if(checkCar.rows.length == 0){
    response.send('Car doesn\'t exist')
  }
  else{

    const checkModel = await pool.query('select * from model where name = $1',[modelname]);
    const checkMake = await pool.query('select * from make where name = $1',[makename]);

    if(checkModel.rows.length > 0){
      modelid = checkModel.rows[0].id;
      console.log('model exists id :' + modelid)
    }
    else{
      const newModel = await pool.query('insert into model (name) values ($1)',[modelname]);
      const newmodelid = await pool.query('select * from model where name = $1',[modelname]);
      modelid = newmodelid.rows[0].id;
      console.log('new model id :' + modelid)
    }

    if(checkMake.rows.length > 0){
      makeid = checkMake.rows[0].id;
      console.log('make exists id :' + makeid)

    }
    else{
      const newMake = await pool.query('insert into make (name) values ($1)',[makename]);
      const newmakeid = await pool.query('select * from make where name = $1',[makename]);
      makeid = newmakeid.rows[0].id;
      console.log('new make id :' + makeid)
   }

   pool.query('UPDATE car SET name = $1, modelid = $2, makeid = $3 WHERE id = $4',[carname, modelid, makeid, id],(error, results) =>{
    if(error){
      throw error;
    }
    console.log('car updated')
    response.status(201).send(`car updated successfully`)
   })

  }

}

const uploadCarImage = async (request, response) => {
  const carId = parseInt(request.params.id)
  let createdDate = new Date();
  let imageName = request.file.filename;
  console.log(imageName);

  if (!request.file) {
    res.status(500).send('file not found')
  } 
  
  const checkCar = await pool.query('select * from car where id = $1',[carId]);

  if(checkCar.rows.length == 0){
    response.send('Car doesn\'t exist')
  }
  else{
    pool.query('insert into carimage (imagename, carid, createddate) values ($1, $2, $3)', [imageName, carId, createdDate], (error, results) =>{
      if(error){
        throw error;
      }
      console.log('carImage added')
      response.status(201).send(`carImage added successfully`)
    })

  }
}

module.exports = {
  getCars,
  getCarById,
  createCar,
  updateCar,
  uploadCarImage,
  getCarsWithImages
}
