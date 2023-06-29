import React from 'react'
import { useGetDevCoEndpoint } from '../queries/devCompany';
import { useParams, useNavigate } from 'react-router-dom';

const DevCompany = () => {
    const { devCoId } = useParams();
    const { data } = useGetDevCoEndpoint(devCoId);
    const navigate = useNavigate();

    const handleGoBack = () => {
        navigate(-1);
    };

    return (
        <div>
            <h1>Dev Company Details</h1>

            <div className="card">
                <div className="card-body">
                    <h5 className="card-title">{data.data.devName}</h5>
                    <p className="card-text">
                        <strong>Address:</strong> {data.data.devAddress}
                    </p>
                    <p className="card-text">
                        <strong>Founded Date:</strong> {data.data.foundedDate}
                    </p>
                    <p className="card-text">
                        <strong>Most Popular Game:</strong> {data.data.mostPopularGame}
                    </p>
                </div>
            </div>

            <div className="mt-5 d-flex justify-content-around">
                <button className="btn btn-primary" onClick={handleGoBack}>
                    Back
                </button>
                <button className="btn btn-primary">Update</button>
                <button className="btn btn-danger">Delete</button>
            </div>
        </div>
    );
}

export default DevCompany;