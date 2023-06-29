import axios from 'axios';
import { useQuery, useQueryClient, useMutation } from '@tanstack/react-query';

export const useGetAllDevCompaniesEndpoint = () => {
    //URL needs to be the same port number as browser port number?
    const { data } = useQuery({
        queryKey: 'Get_DevCompanyList',
        queryFn: async () => await axios.get(`https://localhost:7148/api/DevCompany/GetAllDevCo`)
    });

    return { data };
};

export const useGetDevCoEndpoint = (devCoId) => {

    const { data } = useQuery({
        queryKey: 'Get_DevCompany',
        queryFn: async () => await axios.get(`https://localhost:7148/api/DevCompany/GetDevCo/${devCoId}`)
    });

    return { data };
};

export const useAddDevCompany = (onSuccess) => {

    // Mutations
    const { mutate: saveUTDEndpoint } = useMutation({
        mutationFn: async (data) => axios.post(`https://localhost:7148/api/DevCompany/add`, data),
        onSuccess: () => {
            onSuccess();
        }
    });

    return { saveUTDEndpoint };
    
};
