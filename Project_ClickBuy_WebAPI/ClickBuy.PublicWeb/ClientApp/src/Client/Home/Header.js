import React, { useState } from "react";
import Dropdown from 'react-bootstrap/Dropdown';
import DropdownButton from 'react-bootstrap/DropdownButton';
import { FaSearch } from 'react-icons/fa';
import { FaPhoneAlt } from 'react-icons/fa';
import { FaShoppingCart } from 'react-icons/fa';
import { FaSeedling } from 'react-icons/fa';
import 'bootstrap/dist/css/bootstrap.min.css';
import logo from './../../Img/Image_Header/clickbuy-aar.webp';


const Header = () => {
    const [location, setLocation] = useState(<>Khu vực của bạn: <br /><span style={{ color: "white" }}>Miền Bắc</span></>);
    const [selectedClass, setSelectedClass] = useState("");
    const handleDropdownSelect = (selectedLocation) => {
        setLocation(<>Khu vực của bạn: <br /> <span style={{ color: "White" }}>{selectedLocation}</span> </>);
        if (selectedLocation === "Miền Bắc" || selectedLocation === "Miền Nam") {
            setSelectedClass("selected");
        } else {
            setSelectedClass("");
        }
    };

    return (
        <header className="Header">
            <div className="Header_Home">
                <div className="Logo_Home">
                    <img className="Image_Logo" src={logo} />
                </div>
                <div className="Input_search__Home">
                    <input placeholder="Bạn cần tìm gì?" className="Text_Input_search__HomePage" />
                    <div className="icon_click_search">
                        <FaSearch />
                    </div>
                </div>
                <div className="Location_Header">
                    <DropdownButton id="dropdown-item-button" title={location}>
                        <Dropdown.Item as="button" onClick={() => handleDropdownSelect("Miền Bắc")}>Miền Bắc</Dropdown.Item>
                        <Dropdown.Item as="button" onClick={() => handleDropdownSelect("Miền Nam")}>Miền Nam</Dropdown.Item>
                    </DropdownButton>
                </div>
                <div style={{ display: "flex" }} className="Contact_phone_Click">
                    <a className="Link_ToPhone" href="tel:+0853675166">
                        <div className="Icon_Phone_Header">
                            <FaPhoneAlt />

                        </div>
                        <div className="Contact_phone">
                            <p> Gọi mua hàng</p>
                            <p style={{ fontWeight: 'bold' }}> 0.853.675.166</p>
                        </div>
                    </a>

                </div>
                <div style={{ display: "flex" }} className="Cart_Header">
                    <a className="Link_ToPhone" href="#">
                        <div className="Icon_Phone_Header">
                            <FaShoppingCart />

                        </div>
                        <div className="Contact_phone">
                            <p> Chi tiết</p>
                            <p style={{ fontWeight: 'bold' }}> Giỏ hàng</p>
                        </div>
                    </a>

                </div>
                <div style={{ display: "flex" }} className="Warranty_Policy">
                    <a className="Link_ToPhone" href="#">
                        <div className="Icon_Phone_Header">
                            <FaSeedling />

                        </div>
                        <div className="Contact_phone">
                            <p> Chính sách</p>
                            <p style={{ fontWeight: 'bold' }}> Bảo Hành</p>
                        </div>
                    </a>

                </div>
            </div>
        </header>

    );
};

export default Header;