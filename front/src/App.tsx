import * as React from "react";
import LeftColumnHeaderContainer from "./containers/LeftColumnHeaderContainer";
import RightColumnHeaderContainer from "./containers/RightColumnHeaderContainer";
import DialogListContainer from "./containers/DialogListContainer";
import Auth from "./pages/Auth";

import styles from "./App.module.css";

const App: React.FC = () => {
  return (
    <div className={styles.app}>
      <div className={styles.leftColumn}>
        <LeftColumnHeaderContainer />
        <DialogListContainer />
      </div>

      <div className={styles.rightColumn}>
        <RightColumnHeaderContainer />
        <Auth />
      </div>
    </div>
  );
}

export default App;