import axios from 'axios';
//useQuery is for getting data and useMutation is for changing data
import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query';
import { toast } from 'react-toastify';

//useQuery is set to getList and is returned. getList is now an object that contains other objects such as refetching, loading, errors, etc
export const useGetAllDevCompaniesEndpoint = () => {
    //URL needs to be the same port number as browser port number?
    //Refetch function is returned, and fetchPolicy is used for the query's first execution
    const getList = useQuery({
        //Unique id for query
        queryKey: 'Get_DevCompanyList',
        queryFn: async () => await axios.get(`https://localhost:7148/api/DevCompany/GetAllDevCo`),
        fetchPolicy: "network-only"
    });

    return getList;
};

export const useGetDevCoEndpoint = (devCoId) => {

    const { data } = useQuery({
        queryKey: 'Get_DevCompany',
        queryFn: async () => await axios.get(`https://localhost:7148/api/DevCompany/GetDevCo/${devCoId}`)
    });

    return { data };
};

export const useAddDevCompany = () => {

    // Mutation has functions such as mutate that takes in paramters
    const { mutate: addDevCompany } = useMutation({
        mutationFn: async (data) => axios.post(`https://localhost:7148/api/DevCompany/add`, data),
        onSuccess: () => {
            //Invalidate the old query of getting the list and refetches
            useQueryClient.invalidateQueries('Get_DevCompanyList');
            useQueryClient.refetchQueries('Get_DevCompanyList');
        }
    });


    return { addDevCompany };
    
};

export const useDeleteDevCoEndpoint = (navigate) => {

    const { mutate: deleteCompany } = useMutation({
        mutationFn: async (devCoId) => await axios.delete(`https://localhost:7148/api/DevCompany/delete/${devCoId}`),
        onSuccess: () => {
            //Invalidate the old query of getting the list and refetches
            //Doesn't show updated list when navigating back to DevCompanyList maybe because of async operations?
            useQueryClient.invalidateQueries('Get_DevCompanyList');
            useQueryClient.refetchQueries('Get_DevCompanyList');
        }
    });

    return { deleteCompany };

};