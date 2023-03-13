import React from "react";
import CountdownTimer from "./CountdownTimer";
import ProductSaleHome from "./ProductSaleHome";
import './../../Css/HomePage/FlashSaleHome.scss';
import ImageLogoSale from './../../Img/Image_LogoSaleProduct/flash-sale-moi-ngay.png'
const FlashSaleDay = () => {
    return (
        <div className="Flash_SaleHome">
            <div className="Flash_SaleHome_Top">
                <div className="Flash_SaleHome_Top_Img">
                    <img src={ImageLogoSale}></img>
                </div>
                <div className="Flash_SaleHome_CountDownTime">
                    <CountdownTimer />

                </div>
            </div>
            <div className="ProductSaleHome_AllItem">
                <ProductSaleHome />
            </div>

        </div>
    )
}
export default FlashSaleDay;