import React, { useState, useEffect } from "react";
import './../../Css/HomePage/CountDownTimer.scss'
const CountdownTimer = () => {
    // Sử dụng Hooks
    const [secondsLeft, setSecondsLeft] = useState(86400);
    // Set giá trị thay đổi liên tục
    useEffect(() => {
        const intervalId = setInterval(() => {
            setSecondsLeft((secondsLeft) => secondsLeft - 1);
        }, 1000);

        return () => clearInterval(intervalId);
    }, []);
    // Tính giờ
    const hours = Math.floor(secondsLeft / 3600);
    // Tính phút
    const minutes = Math.floor((secondsLeft - hours * 3600) / 60);
    // Tính phút
    const seconds = secondsLeft % 60;
    return (
        <div className="countdown-timer">
            {/* Render Ra mã HTML */}
            <div className="timer-block">
                <div className="timer-label">Giờ</div>

                <div className="timer-value">{hours.toString().padStart(2, "0")}</div>
            </div>

            <div className="timer-block">
                <div className="timer-label">Phút</div>

                <div className="timer-value">{minutes.toString().padStart(2, "0")}</div>
            </div>

            <div className="timer-block">
                <div className="timer-label">Giây</div>

                <div className="timer-value">{seconds.toString().padStart(2, "0")}</div>
            </div>
        </div>
    );
};

export default CountdownTimer;