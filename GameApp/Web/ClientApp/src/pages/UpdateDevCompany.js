import React from 'react';
import { toast } from 'react-toastify';
import * as yup from "yup";
import { useForm } from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';
import { useNavigate } from 'react-router-dom';

//Validation requirements for input fields
const validationSchema = yup
    .object()
    .shape({
        devName: yup.string().trim().required('Developer company name is required').max(100),
        devAddress: yup.string().trim().required('Developer company address is required').max(100),
        foundedDate: yup.date().required("Developer company founded date is required")
            .max(new Date(), "Future date not allowed")
            .typeError("Developer company founded date is required"),
        mostPopularGame: yup.string().trim().required('Developer company most popular game is required').max(100)
    })
    .required();

const UpdateDevCompany = () => {
    const navigate = useNavigate();

    return (
        <div>
            UPDATEEE
        </div>
    );
}

export default UpdateDevCompany