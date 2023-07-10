import React, { useEffect, useState } from 'react'
import { useGetAllDevCompaniesEndpoint } from '../queries/devCompany';
import './DevCompanyList.css';
import { Link, useNavigate } from 'react-router-dom';

const DevCompanies = () => {
    //useQueryObject is now an object and needs to be destructed
    const useQueryObject = useGetAllDevCompaniesEndpoint();
    //Destructing the useQueryObject
    const { data: { data }, refetch } = useQueryObject;
    const navigate = useNavigate();

    const [filterList, setFilterList] = useState(data);

    useEffect(() => {
        //This is the refetch function from usequery library, it refreshes the query results
        refetch();

        //This console log shows the useQuery object before its destructured
        console.log({ useQueryObject })
        //This console log shows the useQuery object after its destructured
        console.log({ data })
    }, [data]);

    const handleSearch = (e) => {
        console.log(e.target.value)
        if (e.target.value === "") {
            setFilterList(data);
            return;
        }

        //Returns list that has been filtered with condition
        const filterValues = data.filter((data) =>
            //indexOf() method is used to check if the lowercase version of data.devName contains the lowercase value of 
            //e.target.value(the value entered in an input field).The indexOf() method returns the index of the first occurrence 
            //of a given value in a string, or - 1 if the value is not found.
            data.devName.toLowerCase().indexOf(e.target.value.toLowerCase()) !== -1
        );
        setFilterList(filterValues);
    }
    
    return (
        <div>
            <div className='my-4 d-flex justify-content-between'>
                <h1 className='m-2'>Dev Company List</h1>
                <div>
                    <h3>Search: </h3>
                    <input
                        name="query"
                        type="text"
                        onChange={handleSearch}
                    />
                </div>
            </div>
            <ul className="list-group">
                {/*data is now easier to map instead of writing useQueryObject.data.data or something*/}
                {/*data is not empty then map*/}
                {filterList && filterList.map((company) => (
                    <Link to={`/DevCompanyPage/${company.devCoId}`} className='text-decoration-none my-4' key={company.devCoId}>
                        <li key={company.devCoId} className="list-group-item py-4 bg-info text-white custom-list-item d-flex justify-content-between ">
                            <h5>{company.devName}</h5>
                            <h5>></h5>
                        </li>
                    </Link>
                        
                ))}
            </ul>
            <div className='d-flex justify-content-center'>
                <button className='custom-list-item bg-success text-white' onClick={() => { navigate('/AddDevCompany') } }>
                    <h2>
                        +
                    </h2>
                </button>
            </div>
            
        </div>
    );
}

export default DevCompanies;