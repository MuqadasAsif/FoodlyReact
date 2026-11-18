import './Menu.css'
import { useEffect, useState } from 'react'
import { useLocation, useNavigate } from 'react-router-dom'
{/*useLocation:pichli screen se bheja gaya data receive karne ke liye.
 useNavigate:code ke through doosre page par jane ke liye.s    
*/}
function Menu() {

    const location = useLocation(); {/*navigation information deta*/}
    const navigate = useNavigate()
    const restaurant = location.state?.restaurant; {/*navigation ke saath bheja gaya data hai.*/}

    const [menus, setMenus] = useState([])

    useEffect(() => { 

        fetch(`http://localhost:5245/Menu/Restaurant/${restaurant.id}`)
            .then(response => response.json())
            .then(data => {
                console.log(data)
                setMenus(data)
            })
            .catch(error => console.log(error))

    }, [])

    return (
        <div className="menu-page">

            <div className="menu-heading">
                <h1>{restaurant?.name} Menu</h1>
                <p>Select your favorite item.</p>
            </div>

            <div className="menu-list">

                {menus.map((menu) => (
                    <div className="menu-card" key={menu.id}>

                        <h2>{menu.name}</h2>

                        <p>{menu.description}</p>

                        <h3>Rs. {menu.price}</h3>

                        <button
                            onClick={() => navigate('/order', {
                                state: {
                                    restaurant: restaurant,
                                    menu: menu
                                }
                            })}
                        >
                            Select Item
                        </button>

                    </div>
                ))}

            </div>

        </div>
    )
}

export default Menu