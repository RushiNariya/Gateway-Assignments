import React, { useEffect, useState } from "react";
import { getCustomer, getCustomers } from "../../Api/CustomerApi";
import "./customer.css";
import { Modal, Button } from "react-bootstrap";

function MyVerticallyCenteredModal(props) {
  console.log(props.customer.thumbnail);
  return (
    <Modal
      {...props}
      size="lg"
      aria-labelledby="contained-modal-title-vcenter"
      centered
    >
      <Modal.Header closeButton>
        <Modal.Title id="contained-modal-title-vcenter">
          Customer Details
        </Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <div className="row">
          <div className="col-lg-6 imageFlex">
            <img
              className="imageResize"
              src={props.customer.thumbnail}
              alt="Card image cap"
            />
          </div>
          <div className="col-lg-6 tableflex">
            <table className="styled-table">
              <thead>
                <tr>
                  <th>Name</th>
                  <th>Value</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>Name</td>
                  <td>{props.customer.name}</td>
                </tr>
                <tr>
                  <td>email</td>
                  <td>{props.customer.email}</td>
                </tr>
                <tr>
                  <td>contactnumber</td>
                  <td>{props.customer.contactnumber}</td>
                </tr>
                <tr>
                  <td>status</td>
                  <td>{props.customer.status == 1 ? "active" : "Inactive"}</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </Modal.Body>
      <Modal.Footer>
        <Button onClick={props.onHide}>Close</Button>
      </Modal.Footer>
    </Modal>
  );
}

function Customer() {
  const [records, setRecords] = useState({
    data: [],
  });
  const [customer, setCustomer] = useState({});
  const [modalShow, setModalShow] = React.useState(false);

  async function getCustomerById(id) {
    const res = await getCustomer(id);
    console.log(res.data);
    setCustomer(res.data);
    setModalShow(true);
    console.log(customer);
  }

  useEffect(async () => {
    const res = await getCustomers();
    // console.log(res)
    setRecords({
      data: res.data.map((r, index) => {
        return (
          <tr key={r.id}>
            <th scope="row">{index + 1}</th>
            <td>
              <img className="imageResize" src={r.thumbnail} />
            </td>
            <td>{r.name}</td>
            <td>{r.email}</td>
            <td>{r.contactnumber}</td>
            <td className="actions">
              <Button
                variant="primary"
                onClick={getCustomerById.bind(this, r.id)}
              >
                click
              </Button>
            </td>
          </tr>
        );
      }),
    });
  }, []);

  return (
    <div className="scrollit">
      <MyVerticallyCenteredModal
        show={modalShow}
        customer={customer}
        onHide={() => setModalShow(false)}
      />

      <h2>Customer List</h2>
      <table className="table table-hover" id="datatable">
        <thead>
          <tr>
            <th scope="col">#</th>
            <th scope="col">Profile</th>
            <th scope="col">Name</th>
            <th scope="col">Email</th>
            <th scope="col">Contact</th>
            <th scope="col">Details</th>
          </tr>
        </thead>
        <tbody>{records.data}</tbody>
      </table>
    </div>
  );
}

export default Customer;
