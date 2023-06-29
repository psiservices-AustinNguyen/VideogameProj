import React, { useState, useCallback } from 'react'
import { toast } from 'react-toastify';
import * as yup from "yup";
import { useForm } from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';
import { useNavigate } from 'react-router-dom';
import { useAddDevCompany } from '../queries/devCompany';

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



const AddDevCompany = () => {
    const navigate = useNavigate();

    const handleGoBack = () => {
        navigate(-1);
    };

    //UseForm hook that has functions needed with yup library 
    //The register() method allows registering an element and applying the appropriate validation rules.
    //The handleSubmit() function will receive the form data if validation is successful.
    //The reset() function will clear all form fields or reset to initial values.
    //In this case, we are using formState to return form errors in an easier way
    const {
        register,
        handleSubmit,
        formState: { errors },
        reset

    } = useForm({
        resolver: yupResolver(validationSchema)
    });

    const onSuccessCallback = useCallback(() => {
        //reset();
        //toast.success('Developer Company Added', {
        //    position: "top-right",
        //    autoClose: 1500,
        //    hideProgressBar: false,
        //    closeOnClick: true,
        //    pauseOnHover: true,
        //    draggable: true,
        //    progress: undefined,
        //    theme: "light",
        //});
        //navigate('/DevCompanyList')
        console.log("SUCCESS")
    }, [navigate]);

    //const onSubmit = (data) => {
    //    data.preventDefault()
    //    console.log({ data });
    //    reset();
    //}

    //This calls the post request and sets the data to saveUTDEndpoint,
    //the post request takes in a callback function and when the request successfully executes, 
    //the callback function executes
    const { addDevCompany } = useAddDevCompany(onSuccessCallback);
    
    return (
        <div>
            <div className='d-flex justify-content-center'>
                <form className="mt-3 mb-3 " onSubmit={handleSubmit(addDevCompany)}>
                    <div>
                        Name:
                    </div>
                    <label className='mb-2'>
                        <input
                            id="devName"
                            type="text"
                            {...register('devName')}
                        />
                        <p className='text-danger'>{errors.devName?.message}</p>
                    </label>
                    <div>
                        Address:
                    </div>
                    <label className='mb-2'>
                        <input
                            id="devAddress"
                            type="text"
                            {...register('devAddress')}
                        />
                        <p className='text-danger'>{errors.devAddress?.message}</p>
                    </label>
                    <div>
                        Founded Date:
                    </div>
                    <label className='mb-2'>
                        <input
                            id="foundedDate"
                            type="date"
                            {...register('foundedDate')}
                        />
                        <p className='text-danger'>{errors.foundedDate?.message}</p>
                    </label>
                    <div>
                        Most Popular Game:
                    </div>
                    <label className='mb-2'>
                        <input
                            id="mostPopularGame"
                            type="text"
                            {...register('mostPopularGame')}
                        />
                        <p className='text-danger'>{errors.mostPopularGame?.message}</p>
                    </label>
                    <div className='d-flex justify-content-between'>
                        <button className="btn btn-primary" onClick={handleGoBack}>
                            Back
                        </button>
                        <button className="btn btn-success">
                            Submit
                        </button>
                    </div>
                </ form>
            </div>
            
        </div>
    );

}

export default AddDevCompany;