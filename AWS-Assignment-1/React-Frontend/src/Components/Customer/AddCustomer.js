import React, { useState } from "react";
import { addCustomer } from "../../Api/CustomerApi";

function AddCustomer({ history }) {
  const [name, setName] = useState();
  const [email, setEmail] = useState();
  const [password, setPassword] = useState();
  const [contactNumber, setContactNumber] = useState();
  const [image, setImage] = useState();
  const [status, setStatus] = useState(1);

  const handleSubmit = async (e) => {
    e.preventDefault();

    const fd = new FormData();
    fd.append("name", name);
    fd.append("image", image);
    fd.append("password", password);
    fd.append("contactNumber", contactNumber);
    fd.append("email", email);

    const res = await addCustomer(fd);
    console.log(res);
    if (res.status != 201) {
      console.log(res.status);
    } else {
      console.log(res.status);
      history.push("/customers");
    }
  };

  return (
    <div>
      <h2>Register User</h2>
      <form
        className="row g-3 mt-3 m-auto"
        onSubmit={handleSubmit}
        encType="multipart/form-data"
      >
        <div className="col-lg-12 px-lg-5 px-md-3 mt-3">
          <label htmlFor="Name" className="form-label">
            Name
          </label>
          <input
            type="text"
            className="form-control"
            id="Name"
            required
            onChange={(e) => setName(e.target.value)}
          />
        </div>

        <div className="col-lg-12 px-lg-5 px-md-3 mt-3">
          <label htmlFor="Email" className="form-label">
            Email
          </label>
          <input
            type="text"
            className="form-control"
            id="Email"
            required
            onChange={(e) => setEmail(e.target.value)}
          />
        </div>

        <div className="col-lg-12 px-lg-5 px-md-3 mt-3">
          <label htmlFor="Password" className="form-label">
            password
          </label>
          <input
            type="Password"
            className="form-control"
            id="Password"
            required
            onChange={(e) => setPassword(e.target.value)}
          />
        </div>

        <div className="col-lg-12 px-lg-5 px-md-3 mt-3">
          <label htmlFor="Contact" className="form-label">
            Contact Number
          </label>
          <input
            type="Contact"
            className="form-control"
            id="Contact"
            required
            onChange={(e) => setContactNumber(e.target.value)}
          />
        </div>

        <div className="col-lg-12 px-lg-5 px-md-3 mt-3">
          <label htmlFor="Image" className="form-label">
            Image
          </label>
          <input
            type="file"
            className="form-control"
            id="Image"
            required
            onChange={(e) => setImage(e.target.files[0])}
          />
        </div>

        <div className="col-12 mt-4">
          <button type="submit" className="btn btn-primary">
            Add
          </button>
        </div>
      </form>
    </div>
  );
}

export default AddCustomer;
