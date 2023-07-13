import React, { useState } from 'react';
import ShowTestData from '../components/ShowTestData';

const Exercises = () => {
    const [count, setCount] = useState(0);
    const [isVisible, setIsVisible] = useState(false);
    const [countWord, setWordCount] = useState(0);

    const testData = 
    {
        name: 'Joe Smith',
        age: 46,
        occupation: 'Doctor'
    }

    const handleCount = (e) => {
        setWordCount(e.target.value.length)
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

            <div className='my-4'>
                <h1>Character Counter</h1>
                <input
                    type="text"
                    onChange={handleCount}
                />
                <h4>Word Count: {countWord}</h4>
            </div>

            <div className='my-4'>
                <h1>Toggle Exercise</h1>
                <h3>{isVisible && <p>¯\_( ͡❛ ͜ʖ ͡❛)_/¯</p>}</h3>
                <button onClick={() => setIsVisible(!isVisible) }>SHOW ME THE GOODS</button>
            </div>
            
            <h1>Props Exercise</h1>
            <ShowTestData name={testData.name} test={"Test"} test2={"Second Test"} />
        </div>
    );
}

export default Exercises