import React from 'react';
import { Route, Routes } from 'react-router-dom';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import NavMenu from './components/NavMenu';
import DevCompanies from './Pages/DevCompanies';
import HomePage from './Pages/HomePage';

function App() {
    return (
        <div>
            <div>
                <NavMenu />
            </div>
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
            <Routes>
                <Route path="/" element={<HomePage />} />
                <Route path="/DevCompanies" element={<DevCompanies />} />
            </Routes>
        </div>
            
    );
}

export default App;
