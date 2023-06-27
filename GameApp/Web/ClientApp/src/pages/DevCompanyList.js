import React from 'react'
import { useGetAllDevCompaniesEndpoint } from '../queries/devCompany';
import './DevCompanyList.css';

const DevCompanies = () => {
    const { data } = useGetAllDevCompaniesEndpoint();

    console.log({ data })

    return (
        <div>
            <h1 className='m-2'>Dev Company List</h1>
            <ul className="list-group">
                {data &&
                    data.data.map((company) => (
                        <li key={company.devCoId} className="list-group-item py-4 bg-info text-white m-4 custom-list-item d-flex justify-content-between">
                            <h5>{company.devName}</h5>
                            <h5>></h5>
                        </li>
                    ))}
            </ul>
            {/*<div className='d-flex justify-content-center'>*/}
            {/*    <h6>*/}
            {/*        To add a company click here*/}
            {/*    </h6>*/}
            {/*</div>*/}
            <div className='d-flex justify-content-center'>
                <button className='custom-list-item bg-success text-white'>
                    <h2>
                        +
                    </h2>
                    
                </button>
            </div>
            
        </div>
    );
}

export default DevCompanies;