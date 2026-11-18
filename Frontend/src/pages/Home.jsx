import Food from '../assets/Food.jpg'
import KFC from '../assets/KFC.jpg'
import cheezious from '../assets/cheezious.jpg'
import Mcdonald from '../assets/Mcdonald.jpg'
import { Link } from 'react-router-dom'
function Home() {
    return (
        <div>
            <header>
                <h1>Foodly</h1>

                <nav>
                    <Link to="/home">Home</Link> {/* Link user ko us URL par le jata hai.*/}
                    <Link to="/restaurants">Restaurants</Link> {/* react mai <a> ki jagha link use hota <a> sai page dobara reload hota hai lakin link sai nhi reload hota</a> */}
                    <Link to="/orders">Orders</Link>
                    <a href="#">Login</a>
                </nav>
            </header>

            <main>
                <div className="hero-text">
                    <h2>Delicious food, delivered to you</h2>

                    <p>
                        Order your favorite food from your favorite restaurants.
                    </p>

                    <Link to="/restaurants" className="explore-btn">
                        Explore Restaurants
                    </Link>
                </div>

                <div className="hero-image">
                    <img src={Food} alt="Delicious food" />
                </div>
            </main>

            <section className="popular">
                <h2>Popular Restaurants</h2>

                <p>Discover some of the most popular restaurants on Foodly.</p>

                <div className="restaurant-list">

                    <div className="restaurant-card">
                        <img src={KFC} alt="KFC" />
                        <h3>KFC</h3>
                        <p>Fast Food</p>
                        <span>⭐ 4.5</span>
                    </div>

                    <div className="restaurant-card">
                        <img src={cheezious} alt="Cheezious" />
                        <h3>Cheezious</h3>
                        <p>Pizza & Fast Food</p>
                        <span>⭐ 4.3</span>
                    </div>

                    <div className="restaurant-card">
                        <img src={Mcdonald} alt="McDonald's" />
                        <h3>McDonald's</h3>
                        <p>Burgers & Fast Food</p>
                        <span>⭐ 4.4</span>
                    </div>

                </div>
            </section>

            <section className="why-foodly">
                <h2>Why Choose Foodly?</h2>

                <p>Everything you need for a better food ordering experience.</p>

                <div className="features">

                    <div className="feature-card">
                        <h3>⚡ Fast Delivery</h3>
                        <p>
                            Get your favorite meals delivered quickly and conveniently.
                        </p>
                    </div>

                    <div className="feature-card">
                        <h3>🏆 Best Restaurants</h3>
                        <p>
                            Discover popular restaurants and enjoy quality food.
                        </p>
                    </div>

                    <div className="feature-card">
                        <h3>🛒 Easy Ordering</h3>
                        <p>
                            Browse restaurants and order your favorite meals with ease.
                        </p>
                    </div>

                </div>
            </section>

            <footer>
                <div className="footer-content">
                    <div>
                        <h2>Foodly</h2>
                        <p>
                            Delicious food delivered right to your doorstep.
                        </p>
                    </div>

                    <div>
                        <h3>Quick Links</h3>
                        <a href="#">Home</a>
                        <a href="#">Restaurants</a>
                        <a href="#">Orders</a>
                    </div>

                    <div>
                        <h3>Contact</h3>
                        <p>support@foodly.com</p>
                        <p>+92 300 1234567</p>
                    </div>
                </div>

                <div className="footer-bottom">
                    <p>© 2026 Foodly. All rights reserved.</p>
                </div>
            </footer>
        </div>
    )
}

export default Home