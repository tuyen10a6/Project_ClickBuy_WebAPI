import Header from "./Header";
import './../../Css/HomePage/Home.scss'
import Slide_Home from "./Slide_Home";

import FlashSaleDay from './FlashSaleDay'
import ProductApple from "./ProductApple";

const Home = (props) => {
    return (
        <div className="Home_Page">

            <Header />
            <Slide_Home />
            <FlashSaleDay />
            <ProductApple />


        </div>
    )
}
export default Home;