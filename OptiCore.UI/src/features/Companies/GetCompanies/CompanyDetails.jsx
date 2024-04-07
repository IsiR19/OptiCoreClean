import React, { useEffect, useState } from 'react';
import axios from 'axios';

const CompanyDetail = ({ id }) => {
  const [data, setData] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axios.get(`https://localhost:7261/api/GetCompanies`, {
          params: {
            id: id,
          },
        });
        setData(response.data);
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    };

    fetchData();
  }, [id]);

  if (!data) {
    return <div>Loading...</div>;
  }

  return (
    <div>
      <h1>{data.name}</h1>
      <p>Registration Number: {data.registrationNumber}</p>
      {/* Render additional elements */}
    </div>
  );
};

export default CompanyDetail;
