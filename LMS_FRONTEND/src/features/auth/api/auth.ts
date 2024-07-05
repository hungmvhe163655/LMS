import axios from 'axios';

// Define the type for the form data
export interface SupervisorFormData {
  fullname: string;
  email: string;
  phonenumber: string;
  password: string;
}

export async function registerSupervisor(data: SupervisorFormData) {
  const requestBody = {
    fullName: data.fullname,
    userName: data.email,
    email: data.email,
    phoneNumber: data.phonenumber,
    verifiedByUserID: 'c463543c-d1d4-4ca9-81c3-7319462fe76e',
    password: data.password,
    roles: ['SUPERVISOR']
  };

  try {
    const response = await fetch('http://localhost:5002/api/Authentication/RegisterSupervisor', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(requestBody)
    });

    if (!response.ok) {
      throw new Error('Network response was not ok');
    }

    const result = await response.json();
    return result;
  } catch (error) {
    console.error('Error:', error);
    throw error;
  }
}

export const verifyEmail = async (email: string, auCode: string) => {
  try {
    const response = await axios.put('http://localhost:5002/api/Authentication/VerifyEmail', {
      email,
      auCode
    });
    return response.data;
  } catch (error) {
    throw new Error('Invalid Token');
  }
};

export const resendVerifyEmail = async (email: string) => {
  try {
    const response = await axios.put('http://localhost:5002/api/Authentication/ReSendVerifyEmail', {
      email
    });
    return response.data;
  } catch (error) {
    throw new Error('Bad Request');
  }
};
