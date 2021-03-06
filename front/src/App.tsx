import * as React from "react";
import { Route, Routes } from "react-router";
import useInitAuth from "./hooks/useInitAuth";
import useAppSelector from "./hooks/useAppSelector";
import DialogListContainer from "./containers/DialogListContainer";
import LeftColumnHeaderContainer from "./containers/LeftColumnHeaderContainer";
import RightColumnHeaderContainer from "./containers/RightColumnHeaderContainer";
import Auth from "./pages/Auth";
import Chat from "./pages/Chat";
import Profile from "./pages/Profile";
import NotFound from "./pages/NotFound";

import styles from "./App.module.css";
import Home from "./pages/Home";
import useAuth from "./hooks/useAuth";
import useMessagingHub from "./hooks/useMessagingHub";

const App: React.FC = () => {

  const wasInitAuthAttempt = useAppSelector(state => state.auth.wasInitAuthAttempt);

  useInitAuth();
  useAuth();
  useMessagingHub();

  return (
    <div className={styles.app}>
      <div className={styles.leftColumn}>
        <LeftColumnHeaderContainer />
        {wasInitAuthAttempt &&
          <DialogListContainer />}
      </div>

      <div className={styles.rightColumn}>
        <RightColumnHeaderContainer />
        {wasInitAuthAttempt &&
          <Routes>
            <Route element={<Home />} path="/" />
            <Route element={<Chat />} path="/:chatId" />
            <Route element={<Auth />} path="/auth" />
            <Route element={<Profile />} path="/profile" />
            <Route element={<NotFound />} path="*" />
          </Routes>}
      </div>
    </div>
  );
}

export default App;