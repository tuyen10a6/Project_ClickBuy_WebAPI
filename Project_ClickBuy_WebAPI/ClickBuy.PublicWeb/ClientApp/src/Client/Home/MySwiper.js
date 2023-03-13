import React, { useEffect } from 'react';
import DataSlideContent from './../../Data/DataSlideContentHome';

import { Swiper, SwiperSlide } from 'swiper/react';
import { Navigation, Pagination, Scrollbar, A11y } from 'swiper';

// Import Swiper styles
import 'swiper/css';
import 'swiper/css/navigation';
import 'swiper/css/pagination';
import 'swiper/css/scrollbar';


const MySwiper = () => {


  return (
    <Swiper
      modules={[Navigation, Pagination, Scrollbar, A11y]}
      spaceBetween={50}
      slidesPerView={1}
      loop={true}
      speed={1000}
      slidesPerGroup={1}
      navigation

      scrollbar={{ draggable: true }}
    >
      {DataSlideContent.map((slide) => (
        <SwiperSlide key={slide.id}>
          <img src={slide.Image} alt={`Slide ${slide.id}`} />
        </SwiperSlide>
      ))}
    </Swiper>


  );
};

export default MySwiper;