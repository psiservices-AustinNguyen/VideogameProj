import React from 'react'
import { useGetDevCoEndpoint } from '../queries/devCompany';
import { useParams, useNavigate } from 'react-router-dom';
import { useDeleteDevCoEndpoint } from '../queries/devCompany'
import { toast } from 'react-toastify';

const DevCompanyPage = () => {
    const { devCoId } = useParams();
    const { data: { data } } = useGetDevCoEndpoint(devCoId);
    const { deleteCompany } = useDeleteDevCoEndpoint(); // Get the delete mutation from the hook
    const navigate = useNavigate();

    const handleDelete = async () => {
        await deleteCompany(devCoId); // Call the mutate function and pass the devCoId
        toast.success('Developer Company Deleted!', {
            position: "top-right",
            autoClose: 2000,
            hideProgressBar: false,
            closeOnClick: true,
            pauseOnHover: true,
            draggable: true,
            theme: "light",
        });
        navigate('/DevCompanyList');
    }

    return (
        <div>
            <h1>Dev Company Details</h1>

            <div className="card">
                <div className="card-body">
                    <h5 className="card-title">{data.devName}</h5>
                    <p className="card-text">
                        <strong>Address:</strong> {data.devAddress}
                    </p>
                    <p className="card-text">
                        <strong>Founded Date:</strong> {data.foundedDate}
                    </p>
                    <p className="card-text">
                        <strong>Most Popular Game:</strong> {data.mostPopularGame}
                    </p>
                </div>
            </div>

            <div className="mt-5 d-flex justify-content-around">
                <button className="btn btn-primary" onClick={() => navigate(-1)}>
                    Back
                </button>
                <button className="btn btn-primary" onClick={() => navigate('/UpdateDevCompany')}>Update</button>
                <button className="btn btn-danger" onClick={handleDelete}>Delete</button>
            </div>
        </div>
    );
}

export default DevCompanyPage;