import React, { Suspense } from 'react';
import { Route, Routes } from 'react-router-dom';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import NavMenu from './components/NavMenu';
import AddDevCompany from './pages/AddDevCompany';
import DevCompany from './pages/DevCompany';
import DevCompanyList from './pages/DevCompanyList';
import HomePage from './pages/HomePage';

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
                        <Route path="/DevCompany/:devCoId" element={<DevCompany />} />
                        <Route path="/AddDevCompany" element={<AddDevCompany />} />
                    </Routes>
                </Suspense>
            </div>
            
            
        </div>
            
    );
}

export default App;
