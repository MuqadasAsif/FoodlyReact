import './Orders.css'
import { useEffect, useState } from 'react'

function Orders() {

    const [orders, setOrders] = useState([])

    useEffect(() => {

        fetch("http://localhost:5269/Order")
            .then(response => response.json())
            .then(data => setOrders(data))
            .catch(error => console.log(error))

    }, [])

    return (
        <div className="orders-page">

            <div className="orders-heading">
                <h1>My Orders</h1>
                <p>View your recent orders and order details.</p>
            </div>

            <div className="orders-list">

                {orders.map((order) => (
                    <div className="order-card" key={order.id}>

                        <h2>Order #{order.id}</h2>

                        <p>
                            <strong>Customer:</strong> {order.customerName}
                        </p>

                        <p>
                            <strong>Item:</strong> {order.itemName}
                        </p>

                        <p>
                            <strong>Quantity:</strong> {order.quantity}
                        </p>

                        <p className="order-total">
                            Total: Rs. {order.totalAmount}
                        </p>

                    </div>
                ))}

            </div>

        </div>
    )
}

export default Orders