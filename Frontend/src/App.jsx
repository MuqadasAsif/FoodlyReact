import './App.css'
import { BrowserRouter, Routes, Route } from 'react-router-dom'

import Home from './pages/Home'
import Restaurants from './pages/Restaurants'
import Orders from './pages/Orders'
import OrderForm from './pages/OrderForm'
import Menu from './pages/Menu'
function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/home" element={<Home />} />
                <Route path="/restaurants" element={<Restaurants />} /> {/*path="/restaurants" — URL ka address define karta hai.*/}
                <Route path="/orders" element={<Orders />} />            {/*Route batata hai: agar ye URL open ho, to konsa component display karna hai.*/}
                <Route path="/order" element={<OrderForm />} />
                <Route path="/menu" element={<Menu />} />
            </Routes>
        </BrowserRouter>
    )
}

export default App