// // src/api/properties.ts
// const API_URL = 'http://localhost:5172/api/v1/';

// export const fetchTopProperties = async () => {
//   const response = await fetch(`${API_URL}getpropertytop/5`);
//   const data = await response.json();
//   return data.value;
// };

// export const fetchFilteredProperties = async (filters: { propertyName: string, address: string, price: string }) => {
//   const query = new URLSearchParams(filters).toString();
//   const response = await fetch(`${API_URL}getpropertybyfilters?${query}`);
//   const data = await response.json();
//   return data.value;
// };
const API_URL = 'http://localhost:5172/api/v1/';

export const fetchTopProperties = async () => {
  try {
    const response = await fetch(`${API_URL}getpropertytop/5`, {
      method: 'GET',
      headers: {
        'Access-Control-Allow-Origin': '*', // Permite solicitudes de todos los orígenes
        'Content-Type': 'application/json',
      },
    });

    if (!response.ok) {
      throw new Error('Network response was not ok');
    }

    const data = await response.json();
    return data.value;
  } catch (error) {
    console.error('Error fetching top properties:', error);
    throw error;
  }
};

export const fetchFilteredProperties = async (filters: { propertyName: string; address: string;  price: number; }) => {
  try {
  
   const requestBody = {
      Name: filters.propertyName,
      Address: filters.address,
      MinPrice:  Number(filters.price)??null,
      MaxPrice:  Number(filters.price)??null
    };

    const response = await fetch(`${API_URL}getpropertybyfilters`, {
      method: 'POST',
      headers: {
        'Access-Control-Allow-Origin': '*', 
        'Content-Type': 'application/json',
      }, body: JSON.stringify(requestBody)
    });

    if (!response.ok) {
      throw new Error('Network response was not ok');
    }

    const data = await response.json();
    return data.value;
  } catch (error) {
    console.error('Error fetching filtered properties:', error);
    throw error;
  }
};
