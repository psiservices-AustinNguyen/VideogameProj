import React, { useEffect } from 'react'
import { useGetAllDevCompaniesEndpoint } from '../queries/devCompany';
import './DevCompanyList.css';
import { Link, useNavigate } from 'react-router-dom';

const DevCompanies = () => {
    //useQueryObject is now an object and needs to be destructed
    const useQueryObject = useGetAllDevCompaniesEndpoint();
    //Destructing the useQueryObject
    const { data: { data }, refetch } = useQueryObject;
    const navigate = useNavigate();

    const handleClick = () => {
        navigate('/AddDevCompany');
    };

    useEffect(() => {
        //This is the refetch function from usequery library, it refreshes the query results
        refetch();

        //This console log shows the useQuery object before its destructured
        console.log({ useQueryObject })
        //This console log shows the useQuery object after its destructured
        console.log({ data })
    }, []);
    
    return (
        <div>
            <h1 className='m-2'>Dev Company List</h1>
            <ul className="list-group">
                {/*data is now easier to map instead of writing useQueryObject.data.data or something*/}
                {/*data is not empty then map*/}
                {data && data.map((company) => (
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