import * as React from "react";
import useOutsideClick from "../../hooks/useOutsideClick";
import UserModel from "../../models/UserModel";

import styles from "./UserSearchResult.module.css";

interface GroupAndUserSearchResultProps {
  items: UserModel[];
  handleUserItemClick: (userId: number) => void;
  handleOutsideClick?: () => void;
}

const GroupAndUserSearchResult: React.FC<GroupAndUserSearchResultProps> =
  ({
    items,
    handleOutsideClick,
    handleUserItemClick
  }) => {
    const listRef = React.useRef(null);

    if (handleOutsideClick) {
      useOutsideClick(handleOutsideClick, listRef);
    }

    return (
      <>
        {items.length > 0 &&
          <div ref={listRef} className={styles.list}>
            {items.map(user => (
              <div key={user.id} onClick={() => handleUserItemClick(user.id)} className={styles.item}>
                {user.avatarUrl &&
                  <img src={user.avatarUrl} alt="avatar" />
                }
                <span>{user.login}</span>
              </div>
            ))}
          </div>}
      </>
    );
  }

export default React.memo(GroupAndUserSearchResult);
