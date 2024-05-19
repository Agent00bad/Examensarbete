import React from 'react'
import ReactDOM from 'react-dom/client'
import { createBrowserRouter, RouterProvider } from 'react-router-dom'
import "./style/reset.scss"
import Root from './root';
import Home from './Pages/home/Home';
import About from './Pages/about/About';


const router = createBrowserRouter([
  {
    path: "/",
    element: <Root/>,
    children: [
      {
        path: "/",
        element: <Home/>
      },
      {
        path: "/experience",
      },
      {
        path: "/education"
      },
      {
        path: "/projects"
      },
      {
        path: "/About",
        element: <About/>
      }
    ]
  },
]); 

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
)
