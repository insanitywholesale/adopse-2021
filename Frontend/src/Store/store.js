import create from "zustand";

export const useStore = create((set)=>({
    logedIn:false,
    setLogedIn:()=>set(state=>({logedIn:!state.logedIn}))
}))

