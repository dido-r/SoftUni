import './App.css';
import { Footer } from './components/Footer';
import { Home } from './components/Home';
import { Navigation } from './components/Navigation';
import { OrderSection } from './components/OrderSection';
import { Schedule } from './components/Schedule';
import { SiteInfo } from './components/SiteInfo';
import { Speakers } from './components/Speakers';

function App() {
  return (
  <div>
    <Navigation />
    <Home />
      <div className="container">
        <SiteInfo />
        <Speakers />
      </div>
      <OrderSection />
      <Schedule />
      <Footer />      
  </div>
  );
}

export default App;