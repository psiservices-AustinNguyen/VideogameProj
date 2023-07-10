import React, { useState } from 'react';
import ShowTestData from '../components/ShowTestData';

const Exercises = () => {
    const [count, setCount] = useState(0);

    const testData = 
    {
        name: 'Joe Smith',
        age: 46,
        occupation: 'Doctor'
    }
    
    return (
        <div>
            <div className='my-4'>
            <h1>Counter Exercise</h1>
                <button className='m-4 btn btn-danger' onClick={() => setCount(count - 1)}>
                    -
                </button>
                Count: {count}
                <button className='m-4 btn btn-success' onClick={() => setCount(count + 1)}>
                    +
                </button>
            </div>
            
            <h1>Props Exercise</h1>
            <ShowTestData name={testData.name} test={"Test"} test2={"Second Test"} />
        </div>
    );
}

export default Exercises