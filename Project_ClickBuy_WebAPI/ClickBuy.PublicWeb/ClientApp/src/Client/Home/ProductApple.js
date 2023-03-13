import React from "react";
import './../../Css/HomePage/ProductApple.scss'
import DataMenuApple from './../../Data/DataMenuApple'
import DataProductHome from './../../Data/DataProductHome'
import TestApiProduct from "./TestApiProduct";


const ProductApple = () => {
    const productsApple = DataProductHome[0].products.filter((p) => p.id = 1);
    return (

        <div className="Apple_Full">
            <div className="ex_hotlink">
                <h2>
                    Apple - Authorised Reseller
                </h2>
                <TestApiProduct></TestApiProduct>
                <div className="ex_menuscoll">
                    <div className="ex_dmc">
                        <div className="ex_collapse">
                            <ul className="FullItemApple">
                                {DataMenuApple.map((item) => (

                                    <li className="Item_Apple" key={item.id}>
                                        <a > {item.Name}</a>
                                    </li>


                                ))}
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <div className="Product_FullItemHome">
                {
                    productsApple.map((item) => {
                        return (
                            <div key={item.id} className="Item_ProductHome">
                                <a className="Link_Item" href="#" >
                                    <img src={item.Image}></img>
                                    <h3>  {item.Name}</h3>
                                    <div className="Money_Aplle">
                                        <p className='Price_Sale'>{item.priceSale.toLocaleString('vi-VN', { style: 'currency', currency: 'VND' })}</p>
                                        {item.old_price && <del className='original_price'>{item.old_price.toLocaleString('vi-VN', { style: 'currency', currency: 'VND' })}</del>}
                                    </div>
                                </a>
                            </div>
                        )
                    })
                }
            </div>

        </div >
    )
}
export default ProductApple;