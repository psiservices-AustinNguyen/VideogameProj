import React from 'react'

// the ...props is a spread operator
// it takes all the extra named props and puts them into this component
const ShowTestData = ({name, ...props }) => {
    return (
        <div>
            <div>
                {name}
            </div>
            <div>
                {props.test }
            </div>
            <div>
                {props.test2}
            </div>
        </div>
    );
}

export default ShowTestData;