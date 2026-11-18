import './OrderForm.css'
import { useLocation, useNavigate } from 'react-router-dom'
import { useState } from 'react'

function OrderForm() {

    const location = useLocation()
    const navigate = useNavigate()

    const restaurant = location.state?.restaurant; {/* ? ka matlab agr state empty howi t error ki jagha undefined mdg dai daina*/ }
    const menu = location.state?.menu

    const [customerName, setCustomerName] = useState("")
    const [quantity, setQuantity] = useState(1)

    const placeOrder = async () => {

        const order = {
            customerName: customerName,
            restaurantId: restaurant.id,
            itemName: menu.name,
            quantity: Number(quantity), 
            totalAmount: Number(menu.price) * Number(quantity)
        }
        {/*Number() is liye likhte hain taake value ko number (integer ya decimal) mein convert kar sakein, kyun ke React ke input se milne wali value aksar string hoti hai.*/ }
        await fetch("http://localhost:5269/Order", {
            method: "POST",
            headers: {
                "Content-Type": "application/json" 
            },
            body: JSON.stringify(order)
        })

        navigate("/orders")
    }
    {/*header- content type ka matlab hum request body mai jason type ka format bhaij rahy*/ }
    {/*json.stringify javascript kai object ko jason text mai convert karta hai*/ }
    return (
        <div className="order-page">

            <div className="order-container">

                <div className="order-heading">
                    <h1>Place Your Order</h1>
                    <p>Enter your details to place your order.</p>
                </div>

                <div className="selected-restaurant">
                    <h2>{restaurant?.name}</h2>
                    <p>{restaurant?.address}</p>
                </div>

                <div className="order-field">
                    <label>Customer Name</label>
                    {/* value={customerName} — state ki current value input mein dikhata hai.*/}
                    <input
                        type="text"
                        value={customerName} 
                        onChange={(e) => setCustomerName(e.target.value)}
                        placeholder="Enter your name"
                    />
                </div>

                <div className="order-field">
                    <label>Item Name</label>

                    <input
                        type="text"
                        value={menu?.name || ""}
                        readOnly
                    />
                </div>

                <div className="order-field">
                    <label>Item Price</label>

                    <input
                        type="number"
                        value={menu?.price || 0}
                        readOnly
                    />
                </div>
                {/* readOnly — user is input ka text edit nahi kar sakta.*/}
                <div className="order-field">
                    <label>Quantity</label>

                    <input
                        type="number"
                        min="1"
                        value={quantity}
                        onChange={(e) => setQuantity(e.target.value)}
                    />
                </div>

                <button
                    className="place-order-btn"
                    onClick={placeOrder}
                >
                    Place Order
                </button>

            </div>

        </div>
    )
}

export default OrderForm

