import React, { useEffect } from 'react'
import { useGetAllDevCompaniesEndpoint } from '../queries/devCompany';
import './DevCompanyList.css';
import { Link, useNavigate } from 'react-router-dom';

const DevCompanies = () => {
    const { data, refetch } = useGetAllDevCompaniesEndpoint();
    const navigate = useNavigate();

    const handleClick = () => {
        navigate('/AddDevCompany');
    };

    useEffect(() => {
        //This is the refetch function from usequery library, it refreshes the query results 
        refetch();
    }, []);
    
    return (
        <div>
            <h1 className='m-2'>Dev Company List</h1>
            <ul className="list-group">
                {data && data.data.map((company) => (
                    <Link to={`/DevCompany/${company.devCoId}`} className='text-decoration-none' key={company.devCoId}>
                        <li key={company.devCoId} className="list-group-item py-4 bg-info text-white m-4 custom-list-item d-flex justify-content-between ">
                            <h5>{company.devName}</h5>
                            <h5>></h5>
                        </li>
                    </Link>
                        
                ))}
            </ul>
            <div className='d-flex justify-content-center'>
                <button className='custom-list-item bg-success text-white' onClick={handleClick }>
                    <h2>
                        +
                    </h2>
                    
                </button>
            </div>
            
        </div>
    );
}

export default DevCompanies;