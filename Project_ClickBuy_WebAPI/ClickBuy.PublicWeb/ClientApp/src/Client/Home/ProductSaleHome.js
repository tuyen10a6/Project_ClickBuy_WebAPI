// Import Swiper React components
import { Swiper, SwiperSlide } from 'swiper/react';
import DataProductSale from '../../Data/DataProductSaleHome';
import './../../Css/HomePage/ProductSaleHome.scss';
// Import Swiper styles
import 'swiper/css';
import { Autoplay } from 'swiper';
import { FaStar, FaStarHalfAlt } from 'react-icons/fa';
import 'swiper/swiper.min.css';
import 'swiper/scss';



import { Navigation, Pagination, Scrollbar, A11y } from 'swiper';


export default () => {
    // const formattedPrice = price.toLocaleString('vi-VN', { style: 'currency', currency: 'VND' }); // "1.234.567,89 ₫"
    return (
        <Swiper
            modules={[Navigation, Pagination, Scrollbar, A11y]}

            slidesPerView={5}
            loop={false}
            speed={900}
            navigation
            ={{ clickable: true }}

            onSwiper={(swiper) => console.log(swiper)}
            onSlideChange={() => console.log('slide change')}

        >
            {
                DataProductSale.map((item) =>

                    <SwiperSlide className='Product_Sale_Swiper' key={item.id}>
                        <div className="Product_item">
                            <img src={item.Image} className='Product_item_saleImage' />

                            <div className='Product_itemName'>
                                <h2 > {item.ProductName}</h2>
                            </div>
                            <div className='Price_ProductItemSale'>
                                {/*  Thẻ del dùng để gạch giữa value */}
                                <p className='Price_Sale'>{item.priceSale.toLocaleString('vi-VN', { style: 'currency', currency: 'VND' })}</p>
                                {item.old_price && <del className='original_price'>{item.old_price.toLocaleString('vi-VN', { style: 'currency', currency: 'VND' })}</del>}
                            </div>

                            <div className='Product_rating'>
                                {/* <div className='Rating_Star'>
                                    {Array.from({ length: 5 }, (_, i) => {
                                        const ratingDiff = item.Rating - i; // Số lượng ngôi sao cần hiển thị màu vàng hoặc màu xám
                                        let starColor;
                                        if (ratingDiff >= 1) {
                                            starColor = '#ffbb00'; // Màu vàng cho các ngôi sao đã được đánh giá
                                        } else if (ratingDiff === 0.5) {
                                            starColor = 'linear-gradient(to right, #ffbb00 50%, gray 50%)'; // Hiển thị 1 nửa màu vàng và 1 nửa màu xám
                                        } else {
                                            const nextRatingDiff = ratingDiff + 0.5;
                                            if (nextRatingDiff >= 1) {
                                                starColor = 'linear-gradient(to right, #ffbb00 50%, gray 50%)'; // Hiển thị 1 nửa màu vàng và 1 nửa màu xám
                                            } else {
                                                starColor = 'gray'; // Màu xám cho các ngôi sao chưa được đánh giá
                                            }
                                        }
                                        return <FaStar key={i} className='Product_star' style={{ color: starColor }} />;
                                    })}
                                </div> */}

                                <div className='Rating_Star'>
                                    {Array.from({ length: 5 }, (_, i) => {
                                        const ratingDiff = item.Rating - i;
                                        let starColor;
                                        if (ratingDiff >= 1) {
                                            starColor = '#ffbb00';
                                        } else if (ratingDiff > 0) {
                                            if (ratingDiff > 0 && ratingDiff < 1) {
                                                starColor = `linear-gradient(to right, #ffbb00 50%, gray 50%)`;
                                                return <FaStarHalfAlt key={i} className='Product_star' style={{ color: "#ffbb00" }} />;
                                            } else {
                                                starColor = `gray`;
                                            }
                                        } else {
                                            starColor = 'gray';
                                        }
                                        return <FaStar key={i} className='Product_star' style={{ color: starColor }} />;
                                    })}
                                </div>
                                <div className='Rating_Value'>
                                    <p>({item.Evaluate_product} đánh giá) </p>
                                </div>

                            </div>
                        </div>
                    </SwiperSlide>

                )
            }

        </Swiper>
    );
};