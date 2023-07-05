import React, { Suspense } from 'react';
import { Route, Routes } from 'react-router-dom';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import NavMenu from './components/NavMenu';
import AddDevCompany from './pages/AddDevCompany';
import DevCompanyPage from './pages/DevCompanyPage';
import DevCompanyList from './pages/DevCompanyList';
import HomePage from './pages/HomePage';
import UpdateDevCompany from './pages/UpdateDevCompany';

function App() {
    return (
        <div>
            <div>
                <NavMenu />
            </div>
            <div className='m-5'>
                <div>
                    <ToastContainer
                        position="top-right"
                        autoClose={5000}
                        hideProgressBar={false}
                        newestOnTop={false}
                        closeOnClick
                        rtl={false}
                        pauseOnFocusLoss
                        draggable
                        pauseOnHover
                        theme="light"
                    />
                </div>
                <Suspense fallback={<div>Loading...</div>}>
                    <Routes>
                        <Route path="/" element={<HomePage />} />
                        <Route path="/DevCompanyList" element={<DevCompanyList />} />
                        <Route path="/DevCompanyPage/:devCoId" element={<DevCompanyPage />} />
                        <Route path="/AddDevCompany" element={<AddDevCompany />} />
                        <Route path="/UpdateDevCompany" element={<UpdateDevCompany />} />
                    </Routes>
                </Suspense>
            </div>
            
            
        </div>
            
    );
}

export default App;
