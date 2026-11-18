import './Restaurants.css'
import { useEffect, useState } from 'react'
import { Link } from 'react-router-dom'

function Restaurants() {
    const [restaurants, setRestaurants] = useState([])

    useEffect(() => {
        {/*CAlling api in useEffect then storing the result of api in useState*/ }
        fetch("http://localhost:5184/api/Restaurant") 
            .then(response => response.json())
            .then(data => setRestaurants(data))
        {/*setting in useState*/}
    }, [])

    return (
        <div className="restaurants-page">

            <div className="restaurants-heading">
                <h1>Our Restaurants</h1>
                <p>Discover the best restaurants and order your favorite food.</p>
            </div>

            <div className="restaurant-list">

                {restaurants.map((restaurant) => (
                    <div className="restaurant-card" key={restaurant.id}> {/*yahan hum nai restuarant.id is liyai use kiya ta kai react kai pas har resturant ki unique id ho usko identify karnay kai liyai*/}

                        <img
                            src={restaurant.imageUrl}
                            alt={restaurant.name}
                        />

                        <h2>{restaurant.name}</h2>

                        <p>{restaurant.address}</p>

                        <p>⭐ {restaurant.rating}</p>

                        <Link
                            className="order-now-btn"
                            to="/menu"
                            state={{ restaurant: restaurant }}
                        >
                            View Menu
                        </Link>
                        {/*state object mein restaurant naam ki property banao aur usmein current restaurant ka poora object rakh do.*/}
                    </div>
                ))}

            </div>

        </div>
    )
}

export default Restaurants