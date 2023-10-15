import "./style.css";
import React from "react";

interface Props {
}

const Loading: React.FC<Props> = () => {

    return (
        <div className="loading">
            <h1 className="loading-heading">Loading ...</h1>
            <div className="loader-div">
                <span className="loader">
                    <span></span>
                    <span></span>
                </span>
            </div>
        </div>
    );
};

export default Loading;
