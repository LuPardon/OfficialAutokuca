import "./App.css";
import { Route, Routes, BrowserRouter } from "react-router-dom";
import Header from "./components/Header";
import TabSaloni from "./Pages/TabSaloni";
import TabVozila from "./Pages/TabVozila";
import SvaVozila from "./Pages/SvaVozila";
import StranicaVozilo from "./Pages/StranicaVozilo";
import Pocetna from "./Pages/Pocetna";

function App() {
  return (
    <>
      <Header></Header>

      <BrowserRouter>
        <Routes>
          {/* <Route index element={<TabSaloni />} /> */}
          <Route path="/vozila" element={<TabVozila />} />
          <Route path="/pocetna" element={<Pocetna />} />
          <Route path="/saloni" element={<TabSaloni />} />
          <Route path="/sva_vozila" element={<SvaVozila />} />
          <Route path="/sva_vozila/:id" element={<StranicaVozilo />} />
        </Routes>
      </BrowserRouter>
    </>
  );
}

export default App;
