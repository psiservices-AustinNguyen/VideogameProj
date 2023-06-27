import axios from 'axios';
import { useQuery, useQueryClient, useMutation } from '@tanstack/react-query';

export const useGetAllDevCompaniesEndpoint = () => {

    const { data } = useQuery({
        queryKey: 'Get_DevCompanyList',
        queryFn: async () => await axios.get(`https://localhost:7148/api/DevCompany/GetAllDevCo`)
    });

    return { data };
};

export const useGetDevCoEndpoint = (devCoId) => {

    const { data } = useQuery({
        queryKey: 'Get_DevCompany',
        queryFn: async () => await axios.get(`https://localhost:7148/api/DevCompany/GetAllDevCo`)
    });

    return { data };
};