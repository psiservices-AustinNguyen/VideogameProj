import React from 'react'

const HomePage = () => {
    return (
        <div className="container">
            <h1 className="mt-5">Welcome to My Video Game Website</h1>
            <p>Explore the immersive world and embark on exciting adventures!</p>
            <div className="mt-5">
                <h2>Website Features</h2>
                <ul className="list-group">
                    <li className="list-group-item">Create</li>
                    <li className="list-group-item">Read</li>
                    <li className="list-group-item">Update</li>
                    <li className="list-group-item">Delete</li>
                </ul>
            </div>
            <div className="mt-5">
                <h2>Get Started</h2>
                <p>Go to one of the tabs in the navigation bar and go crazy</p>
            </div>
        </div>
    );
}

export default HomePage;