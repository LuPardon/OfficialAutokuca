import "./App.css";
import { Route, Routes, BrowserRouter } from "react-router-dom";
import Header from "./Header";
import TabSaloni from "./TabSaloni";
import TabVozila from "./TabVozila";

function App() {
  return (
    <>
      <Header></Header>

      <BrowserRouter>
        <Routes>
          {/* <Route index element={<TabSaloni />} /> */}
          <Route path="vozila" element={<TabVozila />} />
          <Route path="saloni" element={<TabSaloni />} />
        </Routes>
      </BrowserRouter>
    </>
  );
}

export default App;
