import axios from 'axios';
import { useQuery, useQueryClient, useMutation } from '@tanstack/react-query';

export const useGetAllDevCompaniesEndpoint = () => {
    //URL needs to be the same port number as browser port number?
    const { data, refetch } = useQuery({
        queryKey: 'Get_DevCompanyList',
        queryFn: async () => await axios.get(`https://localhost:7148/api/DevCompany/GetAllDevCo`),
        fetchPolicy: "network-only"
    });

    return { data, refetch };
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
    });

    return { addDevCompany };
    
};

export const useDeleteDevCoEndpoint = (devCoId) => {

    //const { data } = useQuery({
    //    queryKey: 'Delete_DevCompany',
    //    queryFn: async () => await axios.delete(`https://localhost:7148/api/DevCompany/delete/${devCoId}`)
    //});

    const { mutate: deleteCompany } = useMutation({
        mutationFn: async (devCoId) => await axios.delete(`https://localhost:7148/api/DevCompany/delete/${devCoId}`),
    });

    return { deleteCompany };

};