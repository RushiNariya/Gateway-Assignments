import axios from "axios";

export const getCustomers = () => {
  return axios
    .get(
      "https://tburh9qwge.execute-api.ap-south-1.amazonaws.com/dev/customer"
    )

};


export const getCustomer = (id) => {
  console.log(id);
    return axios
      .get(
        `https://tburh9qwge.execute-api.ap-south-1.amazonaws.com/dev/${id}`
      )
  
  };

  export const addCustomer = async (customerDetails) => {
    console.log(customerDetails)
    return axios
      .post("https://tburh9qwge.execute-api.ap-south-1.amazonaws.com/dev/customer", customerDetails);
  };